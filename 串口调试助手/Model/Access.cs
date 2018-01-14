using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using ADOX;
using System.Drawing;
using System.Windows.Forms;

namespace 串口调试助手
{
    class Access
    {
        private string connection;
        private string filePath;
        private ADOX.Catalog catalog = new Catalog();
        private Md5 md5 = new Md5();

        public Access(string filePath)
        {
            this.filePath = filePath;
            this.connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
        }


        /// <summary>
        /// 创建数据库
        /// </summary>
        public void creatDataDB()
        {

            if (!File.Exists(filePath))  //如果数据库不存在，那就添加数据库
            {
                try
                {
                    catalog.Create(connection);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + ex);
                }
            }
        }


        /// <summary>
        /// 创建管理员和普通用户用户表
        /// </summary>
        /// <param name="tableName"></param>
        public void createUserTable(string tableName)
        {
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {

                    //sql语句,
                    string queryString = "create table " + tableName + " (id AUTOINCREMENT primary key, 用户名 varchar(50) NOT NULL, 密码 varchar(50) NOT NULL)";
                    OleDbConnection cn = new OleDbConnection(connection);

                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(queryString, cn);

                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("i: " + i);
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();


                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能创建表");
                // MessageBox.Show("数据库不存在，不能创建表");
            }
        }


        /// <summary>
        /// 插入用户或者管理员，插入成功返回true
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fileName"></param>
        public bool insertUser(string tableName, string name, string password)
        {
            bool flag = false;
            try
            {
                if (searchUser(tableName, name) == null)
                {
                    string queryString = "insert into " + tableName + " (用户名,密码) values( '" + name + "' , '" + password + "')";
                    //string queryString = "insert into " + tableName + " (用户名,密码) values('', '" + name + "' , '" + password + "')";
                    //string queryString = "insert into " + tableName + " values('1','admin','admin')";
                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(queryString, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();
                    flag = true;
                }
                else
                {
                    Console.WriteLine("用户名已存在！");
                    //MessageBox.Show("用户名已存在！");
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from insertUser: " + ex);
            }

            return flag;
        }

        /// <summary>
        /// 查找用户，并且返回密码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        public string searchUser(string tableName, string name)
        {
            string password = null;
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    bool flag = false;
                    string queryString = "select 用户名, 密码 from " + tableName + " where 用户名 = " + " '" + name + "' ";


                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbDataAdapter adapter;
                    adapter = new OleDbDataAdapter(queryString, cn);

                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        foreach (DataColumn col in set.Tables[0].Columns)
                        {
                            Console.Write(row[col].ToString() + '\t');

                            if (name == row["用户名"].ToString())  //如果查找到相同的用户名，则返回密码，且退出循环
                            {
                                flag = true;
                                password = row["密码"].ToString();
                                break;
                            }
                        }
                        Console.WriteLine();
                    }

                    if (!flag)
                    {
                        Console.WriteLine("没有此用户！");
                        //MessageBox.Show("没有此用户！");
                    }

                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error from searchUser: " + ex);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能查询表");
                // MessageBox.Show("数据库不存在，不能创建表");
            }

            return password;
        }


        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="config"></param>
        public bool updatePassword(string tableName, string name, string oldPWD, string newPWD)
        {
            bool flag = false;
            try
            {
                string password = searchUser(tableName, name);
                if (password != null)
                {
                    if (password == oldPWD) //输入验证的没有  md5 加密
                    {

                        OleDbConnection cn = new OleDbConnection(connection);
                        cn.Open();

                        string str = "update " + tableName + " set 密码 = '" + newPWD + "' where 用户名 = '" + name + "' ";

                        OleDbCommand cmd = new OleDbCommand(str, cn);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cn.Close();
                        cn.Dispose();
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine("密码错误！");
                        //MessageBox.Show("密码错误！");
                    }
                }

                else
                {
                    Console.WriteLine("不存在此用户!");
                    //  MessageBox.Show("不存在此用户!");
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from updateConfig : " + ex);
            }

            return flag;
        }



        /// <summary>
        /// 删除普通用户
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool deleteUser(string tableName, string name)
        {
            bool flag = false;
            try
            {
                if (searchUser(tableName, name) != null)
                {
                    string quertString = "delete * from " + tableName + " where 用户名 = '" + name + "' ";
                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(quertString, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();
                    flag = true;

                }
                else
                {
                    Console.WriteLine("此用户不存在！");
                    // MessageBox.Show("不存在此用户!");
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from updateConfig : " + ex);
            }

            return flag;

        }


        /// <summary>
        /// 创建温度折线图表
        /// </summary>
        /// <param name="tableName"></param>
        public void createPictureTable(string tableName)
        {
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    string queryString = "create table " + tableName + " (id AUTOINCREMENT primary key, 用户类型 varchar(50), 用户名 varchar(50), 图片名 varchar(50), 图片 OLEObject)";
                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(queryString, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();

                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能创建表");
                MessageBox.Show("数据库不存在，不能创建表");
            }
        }


        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fileName"></param>
        public void insertPicutre(string tableName, string userType, string userName, string pictureName, string fileName)
        {
            try
            {

                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fs);
                byte[] data = binaryReader.ReadBytes((int)fs.Length);

                Console.WriteLine("输入图片信息：" + Encoding.Default.GetString(data));

                //string queryString = "insert into " + tableName + " (图片名, 图片) values( '" + pictureName + "', '" + data + "')";  //原来的语句，插入图片不完整
                string queryString1 = "insert into " + tableName + " (用户类型, 用户名, 图片名, 图片) values (@type, @name, @pic, @data)";  //改良后的语句，插入图片完整


                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbCommand cmd = new OleDbCommand(queryString1, cn);

                cmd.Parameters.Add("@type", OleDbType.VarChar).Value = userType;
                cmd.Parameters.Add("@name", OleDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@pic", OleDbType.VarChar).Value = pictureName;
                cmd.Parameters.Add("@data", OleDbType.Binary).Value = data;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from insertPicture: " + ex);
            }
        }


        /// <summary>
        /// "管理员"查找所有图片
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        public List<string> searchPictureName(string tableName)
        {
            List<string> ListName = new List<string>();
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    string queryString = "select 用户类型, 用户名, 图片名 from " + tableName;
                    DataSet set = new DataSet();

                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbDataAdapter adapter;
                    adapter = new OleDbDataAdapter(queryString, cn);

                    adapter.Fill(set);

                    int colNum = set.Tables[0].Columns.Count;  //列数
                    int rowNum = set.Tables[0].Rows.Count;   //行数


                    for (int rowLine = 0; rowLine < rowNum; rowLine++)
                    {
                        string pictureName = null;

                        for (int colLine = 0; colLine < colNum; colLine++)
                        {

                            if (colLine != colNum - 1)   //在最后一个元素后面不用加上连接符号 '-'; 
                                pictureName += set.Tables[0].Rows[rowLine][colLine].ToString() + '~';
                            else
                                pictureName += set.Tables[0].Rows[rowLine][colLine].ToString();
                        }

                        // pictureName = set.Tables[0].Rows[rowLine][0].ToString();

                        ListName.Add(pictureName);

                    }
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error from searchPictureName: " + ex);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能查询表");
                // MessageBox.Show("数据库不存在，不能创建表");
            }

            return ListName;
        }


        /// <summary>
        /// “一般用户”查找图片
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="userType">用户类型</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public List<string> searchPictureName(string tableName, string userType, string userName)
        {
            List<string> ListName = new List<string>();
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    string queryString = "select 用户类型, 用户名, 图片名 from " + tableName + " where 用户类型 = '" + userType + "' and " + "用户名 = '" + userName + "' ";
                    DataSet set = new DataSet();

                    OleDbConnection cn = new OleDbConnection(connection);
                    cn.Open();

                    OleDbDataAdapter adapter;
                    adapter = new OleDbDataAdapter(queryString, cn);

                    adapter.Fill(set);

                    int colNum = set.Tables[0].Columns.Count;  //列数
                    int rowNum = set.Tables[0].Rows.Count;   //行数

                    for (int rowLine = 0; rowLine < rowNum; rowLine++)
                    {
                        string pictureName = null;

                        for (int colLine = 0; colLine < colNum; colLine++)
                        {

                            if (colLine != colNum - 1)   //在最后一个元素后面不用加上连接符号 '-'; 
                                pictureName += set.Tables[0].Rows[rowLine][colLine].ToString() + '~';
                            else
                                pictureName += set.Tables[0].Rows[rowLine][colLine].ToString();
                        }

                        // pictureName = set.Tables[0].Rows[rowLine][0].ToString();

                        ListName.Add(pictureName);

                    }

                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error from searchPictureName: " + ex);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能查询表");
                // MessageBox.Show("数据库不存在，不能创建表");
            }

            return ListName;
        }


        /// <summary>
        /// get 一张 图片
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="pictureName"></param>
        public byte[] getPicture(string tableName, string userType, string userName, string pictureName)
        {
            byte[] pictureByte = null;
            try
            {
                //string queryString = "select 图片 from " + tableName + " where ";
                string queryString = "select 图片 from " + tableName + " where 用户类型 = '" + userType + "' And 用户名 = '" + userName + "' And  图片名 = '" + pictureName + "' ";
                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbCommand cmd = new OleDbCommand(queryString, cn);

                pictureByte = (byte[])cmd.ExecuteScalar();

                Console.WriteLine("输出图片信息：" + Encoding.Default.GetString(pictureByte));

                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from getPicture: " + ex);
            }

            return pictureByte;
        }



        /// <summary>
        /// 创建温度信息表
        /// </summary>
        /// <param name="tableName"></param>
        public void createTemperatureTable(string tableName)
        {
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    string queryString = "create table " + tableName + " (id AUTOINCREMENT primary key, 用户类型 varchar(50), 用户名 varchar(50) , 时间 varchar(50), 温度 varchar(50), 采样地点 varchar(50))";
                    OleDbConnection cn = new OleDbConnection(connection);

                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(queryString, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能创建表");
                MessageBox.Show("数据库不存在，不能创建表");
            }
        }


        /// <summary>
        /// 插入温度数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <param name="datatime"></param>
        /// <param name="temperarture"></param>
        public void insertTemperature(string tableName, string userType, string userName, string datatime, string temperarture, string place)
        {
            try
            {
                string queryString = "insert into " + tableName + " (用户类型, 用户名, 时间, 温度, 采样地点) values( '" + userType + "' ,'" + userName + "' , '" + datatime + "' , '" + temperarture + "', '" + place + "' )";
                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbCommand cmd = new OleDbCommand(queryString, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from insertTemperature: " + ex);
            }
        }


        /// <summary>
        /// 查询温度表全部内容，后来发现可以查询所有的表的内容
        /// </summary>
        /// <param name="tableName"></param>
        public List<string> searchTable(string tableName)
        {
            List<string> list = new List<string>();
            string queryString = null;
            try
            {
                if (LoginForm.userType == "管理员")  //如果是管理员
                    queryString = "select * from " + tableName;  //寻找配置
                else
                    queryString = "select * from " + tableName + " where 用户类型 = '" + LoginForm.userType + "' And 用户名 = '" + LoginForm.userName + "' ";

                DataSet set = new DataSet();

                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbDataAdapter adapter;
                adapter = new OleDbDataAdapter(queryString, cn);

                adapter.Fill(set);

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    string temperature = null;
                    int colNum = set.Tables[0].Columns.Count;
                    int i = 0;

                    foreach (DataColumn col in set.Tables[0].Columns)
                    {
                        //Console.Write(row[col].ToString() + '-');
                        i++;
                        if (i != colNum)   //在最后一个元素后面不用加上连接符号 '-'; 
                            temperature += row[col].ToString() + '~';
                        else
                            temperature += row[col].ToString();

                    }
                    list.Add(temperature);
                    Console.WriteLine();
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from searchTable: " + ex);
            }

            //return temperature;
            return list;
        }



        /// <summary>
        /// "管理员"根据条件 “查询温度表全部内容” 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="place">采样地点</param>
        /// <param name="timeFrom">开始的时间</param>  时间段
        /// <param name="timeTo">结束的时间</param>
        /// <returns></returns>
        public List<string> searchTemperature(string tableName, string place, DateTime timeFrom, DateTime timeTo)
        {
            List<string> list = new List<string>();

            try
            {
                string queryString = null;
                if (place.Length > 0)// 如果查询中有查询地址的，就需要加上地址查询
                {
                    queryString = "select * from " + tableName + " where 采样地点 = " + " '" + place + "' ";
                }
                else //如果地址值为空，就不必要查询地址
                {
                    queryString = "select * from " + tableName;
                }

                DataSet set = new DataSet();
                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbDataAdapter adapter;
                adapter = new OleDbDataAdapter(queryString, cn);

                adapter.Fill(set);

                int colNum = set.Tables[0].Columns.Count;  //列数
                int rowNum = set.Tables[0].Rows.Count;   //行数


                for (int rowLine = 0; rowLine < rowNum; rowLine++)
                {
                    string temperature = null;

                    //int colLine = 0;

                    DateTime accessDate = Convert.ToDateTime(set.Tables[0].Rows[rowLine]["时间"].ToString());  // 计算数据库温度记录的时间

                    if (DateTime.Compare(accessDate, timeFrom) >= 0 && DateTime.Compare(accessDate, timeTo) <= 0)
                    {

                        for (int colLine = 0; colLine < colNum; colLine++)
                        {

                            if (colLine != colNum - 1)   //在最后一个元素后面不用加上连接符号 '-'; 
                                temperature += set.Tables[0].Rows[rowLine][colLine].ToString() + '~';
                            else
                                temperature += set.Tables[0].Rows[rowLine][colLine].ToString();
                        }
                        list.Add(temperature);

                    }

                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from searchTemperature: " + ex);
            }
            return list;
        }


        /// <summary>
        /// "管理员"根据条件 “查询温度表全部内容” 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="place">采样地点</param>
        /// <param name="timeFrom">开始的时间</param>  时间段
        /// <param name="timeTo">结束的时间</param>
        /// <returns></returns>
        public List<string> searchTemperature(string tableName, string userType, string userName, string place, DateTime timeFrom, DateTime timeTo)
        {
            List<string> list = new List<string>();

            try
            {
                string queryString = null;
                if (place.Length > 0)// 如果查询中有查询地址的，就需要加上地址查询
                {
                    queryString = "select * from " + tableName + " where 用户类型 = '" + userType + "' and 用户名 = '" + userName + "'   and 采样地点 = " + " '" + place + "' ";
                }
                else //如果地址值为空，就不必要查询地址
                {
                    queryString = "select * from " + tableName;
                }

                DataSet set = new DataSet();
                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbDataAdapter adapter;
                adapter = new OleDbDataAdapter(queryString, cn);

                adapter.Fill(set);

                int colNum = set.Tables[0].Columns.Count;  //列数
                int rowNum = set.Tables[0].Rows.Count;   //行数


                for (int rowLine = 0; rowLine < rowNum; rowLine++)
                {
                    string temperature = null;

                    //int colLine = 0;

                    DateTime accessDate = Convert.ToDateTime(set.Tables[0].Rows[rowLine]["时间"].ToString());  // 计算数据库温度记录的时间

                    if (DateTime.Compare(accessDate, timeFrom) >= 0 && DateTime.Compare(accessDate, timeTo) <= 0)
                    {

                        for (int colLine = 0; colLine < colNum; colLine++)
                        {

                            if (colLine != colNum - 1)   //在最后一个元素后面不用加上连接符号 '-'; 
                                temperature += set.Tables[0].Rows[rowLine][colLine].ToString() + '~';
                            else
                                temperature += set.Tables[0].Rows[rowLine][colLine].ToString();
                        }
                        list.Add(temperature);

                    }

                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from searchTemperature: " + ex);
            }
            return list;
        }

        /// <summary>
        /// 创建串口配置信息表
        /// </summary>
        /// <param name="tableName"></param>
        public void createConfigTable(string tableName)
        {
            if (File.Exists(filePath))//如果数据库存在
            {
                try
                {
                    string queryString = "create table " + tableName + " (端口 varchar(50), 波特率 varchar(50), 数据位 varchar(50), 停止位 varchar(50), 接收设置 varchar(50), 发送设置 varchar(50))";
                    OleDbConnection cn = new OleDbConnection(connection);

                    cn.Open();

                    OleDbCommand cmd = new OleDbCommand(queryString, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.Close();
                    cn.Dispose();


                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("数据库不存在，不能创建表");
                MessageBox.Show("数据库不存在，不能创建表");
            }
        }


        /// <summary>
        /// 查找串口配置
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        public string[] searchConfig(string tableName)
        {
            string[] config = new string[6];

            try
            {
                string queryString = "select * from " + tableName;  //寻找配置
                DataSet set = new DataSet();

                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbDataAdapter adapter;
                adapter = new OleDbDataAdapter(queryString, cn);

                adapter.Fill(set);

                //(端口 varchar(50), 波特率 varchar(50), 数据位 varchar(50), 停止位 varchar(50), 接收设置 varchar(50), 发送设置 varchar(50))"
                config[0] = set.Tables[0].Rows[0]["端口"].ToString();
                config[1] = set.Tables[0].Rows[0]["波特率"].ToString();
                config[2] = set.Tables[0].Rows[0]["数据位"].ToString();
                config[3] = set.Tables[0].Rows[0]["停止位"].ToString();
                config[4] = set.Tables[0].Rows[0]["接收设置"].ToString();
                config[5] = set.Tables[0].Rows[0]["发送设置"].ToString();

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from searchUser: " + ex);
            }

            return config;
        }


        /// <summary>
        /// 更新串口配置, 如果表中还没有数据，就需要insert 一条数据，如果有数据，则更新，必须数据量只能是一条
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public void updateConfig(string tableName, string[] config)
        {
            try
            {

                string queryString = "select 端口 from " + tableName;
                DataSet set = new DataSet();

                OleDbConnection cn = new OleDbConnection(connection);
                cn.Open();

                OleDbDataAdapter adapter;
                adapter = new OleDbDataAdapter(queryString, cn);

                adapter.Fill(set);

                string str;
                if (set.Tables[0].Rows.Count == 0)  //计算行数, 如果配置没有参数设置，则需要insert，如股count == 1 ，则更新
                {
                    str = "insert into " + tableName + " (端口,波特率,数据位,停止位,接收设置,发送设置) values( '" + config[0] + "' , '" + config[1] + "' , '" + config[2] + "' , '" + config[3] + "' , '" + config[4] + "' , '" + config[5] + "' )";
                }

                else
                {
                    str = "update " + tableName + " set 端口 = '" + config[0] + "',  波特率 = '" + config[1] + "', 数据位 = '" + config[2] + "', 停止位 = '" + config[3] + "', 接收设置 = '" + config[4] + "', 发送设置 = '" + config[5] + "' "; //寻找配置
                }

                OleDbCommand cmd = new OleDbCommand(str, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("error from updateConfig : " + ex);
            }

        }




    }
}