using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Text;

/// <summary>
///ReturnView 的摘要说明：
///根据数据库查询返回的DATASET把其中的数据存储在数组A B C D E 中 
///并将数据转换为json格式
/// </summary>
public class ReturnView
{
    private int v1 = 0;
    private int v2 = 0;
    private int v3 = 0;
    private int v4 = 0;
    private int v5 = 0;
    //yongDataSet给类初始化
    private string[,] a;//数组未初始化关于数组方面的知识http://blog.sina.com.cn/s/blog_48dd82bd01000a8k.html
    private string[,] b;
    private string[,] c;
    private string[,] d;
    private string[,] e;

    public ReturnView(DataSet dataset)
    {
        a = new string[100,5];
        b = new string[100,5];
        c = new string[100,5];
        d = new string[100,5];
        e = new string[100,5];//对数组进行初始化，DOTO统计用户表中每个页面的app数目动态给数组进行初始化
        DataSet Aput = dataset;
        DataTable table = Aput.Tables[0];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            DataRow ARow = table.Rows[i];
            int view = Convert.ToInt32(ARow["ViewID"]);//根据数据的列名获取数据值
            switch (view)
            {
                case 1: this.a[v1, 0] = ARow["AppName"].ToString(); this.a[v1, 1] = ARow["AppIcon"].ToString(); this.a[v1, 2] = ARow["AppAddress"].ToString(); a[v1, 3] = ARow["AppWidth"].ToString(); a[v1, 4] = ARow["AppHeight"].ToString(); v1++; break;
                case 2: b[v2, 0] = ARow["AppName"].ToString(); b[v2, 1] = ARow["AppIcon"].ToString(); b[v2, 2] = ARow["AppAddress"].ToString(); b[v2, 3] = ARow["AppWidth"].ToString(); b[v2, 4] = ARow["AppHeight"].ToString(); v2++; break;
                case 3: c[v3, 0] = ARow["AppName"].ToString(); c[v3, 1] = ARow["AppIcon"].ToString(); c[v3, 2] = ARow["AppAddress"].ToString(); c[v3, 3] = ARow["AppWidth"].ToString(); c[v3, 4] = ARow["AppHeight"].ToString(); v3++; break;
                case 4: d[v4, 0] = ARow["AppName"].ToString(); d[v4, 1] = ARow["AppIcon"].ToString(); d[v4, 2] = ARow["AppAddress"].ToString(); d[v4, 3] = ARow["AppWidth"].ToString(); d[v4, 4] = ARow["AppHeight"].ToString(); v4++; break;
                case 5: e[v5, 0] = ARow["AppName"].ToString(); e[v5, 1] = ARow["AppIcon"].ToString(); e[v5, 2] = ARow["AppAddress"].ToString(); e[v5, 3] = ARow["AppWidth"].ToString(); e[v5, 4] = ARow["AppHeight"].ToString(); v5++; break;
            }
        }

    }

    /// <summary>
    /// 摘要：将数组转换成json格式
    /// </summary>
    /// <param name="array"></param>
    /// <param name="v"></param>
    /// <param name="view"></param>
    /// <returns></returns>
    private StringBuilder ToJson(string[,] array, int v,string view)
    {
        StringBuilder jsonString = new StringBuilder();
        jsonString.Append("\""+view+"\":[");
        for (int i = 0; i < v;i++ )
        {
           
                jsonString.Append("{\"AppName\":\"" + array[i, 0]+"\",");
                jsonString.Append("\"AppIcon\":\"" + array[i, 1] + "\",");
                jsonString.Append("\"AppAddress\":\"" + array[i, 2] + "\",");  
                jsonString.Append("\"AppWidth\":\"" + array[i, 3] + "\",");
                jsonString.Append("\"AppHeight\":\"" + array[i, 4] + "\"},");
        }
        jsonString.Remove(jsonString.Length-1,1);
        jsonString.Append("],");
        return jsonString;

    }

    public string ReturnJson()
    {
        string s = "{" + ToJson(a, v1, "view1") + ToJson(b, v2, "view2") + ToJson(c, v3, "view3")+
            ToJson(d, v4, "view4") + ToJson(e, v5, "view5");
        s= s.Remove(s.Length-1);//remove函数执行完毕后是一个新的字符串，必须赋值回去才能改变源字符串的值
        s = s + "}";
        return s;
    }
}