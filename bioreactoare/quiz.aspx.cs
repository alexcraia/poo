using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class quiz : System.Web.UI.Page
{


    static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    SqlConnection conn = new SqlConnection(connectionString);
    inRaspunsSimplu[] raspSimplu = new inRaspunsSimplu[10];
    inRaspunsMultiplu[] raspMultiplu = new inRaspunsMultiplu[10];
    public string mata;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn.Open();
        if (!string.IsNullOrEmpty(Request["intrebare"]))
        {
            int id_intrebare = int.Parse(Request["intrebare"].ToString());
            Panel1.Visible = false;
            Panel2.Visible = true;
            
            intrebareTextBox.Text = mata;


        }
    }
    users user = new users();
    protected void buttonStart_Click(object sender, EventArgs e)
    {
        string sql = "INSERT INTO utilizatori (nume, email, punctaj) VALUES ('" + textBoxNume.Text + "', '" + textBoxEmail.Text + "', 0)";
        SqlCommand comm = new SqlCommand(sql, conn);
        //comm.ExecuteNonQuery();
        user.numef = textBoxNume.Text;
        user.emailf = textBoxEmail.Text;
        sql = "SELECT * FROM intrebari WHERE tip=1";
        comm = new SqlCommand(sql, conn);
        SqlDataReader read = comm.ExecuteReader();
        int i = 0;
        mata = "MATA";
        while (read.Read())
        {
            raspSimplu[i] = new inRaspunsSimplu(read[1].ToString(), read[2].ToString(), int.Parse(read[3].ToString()));
            i++;
        }
        read.Close();
        sql = "SELECT * FROM intrebari WHERE tip=2";
        comm.CommandText = sql;
        read = comm.ExecuteReader();
        i = 0;
        while (read.Read())
        {
            raspMultiplu[i] = new inRaspunsMultiplu(read[1].ToString(), read[2].ToString(), read[3].ToString());
            i++;
        }
        Response.Redirect("quiz.aspx?intrebare=2");
    }

}
public class users
{
    private string nume;
    private string email;
    private double punctaj;
    public users()
    {
        punctaj = 0;
    }
    public string numef
    {
        get
        {
            return nume;
        }
        set
        {
            nume = value;
        }
    }
    public string emailf
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }
    public double punctajf
    {
        get
        {
            return punctaj;
        }
        set
        {
            punctaj += value;
        }
    }
}
public class intrebare
{
    protected string intreb;
    protected string[] raspunsuri;
    public string intrebf
    {
        get
        {
            return intreb;
        }
        set
        {
            intreb = value;
        }
    }
    public string[] raspunsurif
    {
        get
        {
            return raspunsuri;
        }
        set
        {
            raspunsuri = value;
        }
    }
}
public class inRaspunsSimplu : intrebare
{
    private int raspunsCorect;
    public inRaspunsSimplu(string intrebare, string raspuns, int raspunsCorec)
    {
        intreb = intrebare;
        raspunsuri = raspuns.Split(new string[] { "xx" }, StringSplitOptions.None);
        raspunsCorect = raspunsCorec;
    }
    public int raspunsCorec
    {
        get
        {
            return raspunsCorect;
        }
        set
        {
            raspunsCorect = value;
        }
    }
    public inRaspunsSimplu readDb(int id)
    {

        inRaspunsSimplu intr = new inRaspunsSimplu("etc","etc", 1);
        return intr;
    }
}
public class inRaspunsMultiplu : intrebare
{
    private int[] raspunsCorect;
    public inRaspunsMultiplu(string intrebare, string raspuns, string raspunsCorec)
    {
        intreb = intrebare;
        raspunsuri = raspuns.Split(new string[] { " || " }, StringSplitOptions.None);
        string[] corect = raspunsCorec.Split(new string[] { "xx" }, StringSplitOptions.None);
        for (int i = 0; i < corect.Length - 1; i++)
            raspunsCorect[i] = int.Parse(corect[i]);
    }
    public int[] raspunsCorec
    {
        get
        {
            return raspunsCorect;
        }
        set
        {
            raspunsCorect = value;
        }
    }
}