using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProtoFinal
{
    public partial class Shop : System.Web.UI.Page
    {
        String user_id;
        List<Book> cart;
        List<Book> books;
        List<CheckBox> boxes;
        List<DropDownList> dropList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                user_id = Session["userid"].ToString();
                PopulateCart();
                PopulateBooks();
            }
        }

        protected void PopulateCart()
        {
            cart = new List<Book>();
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);
            conn.Open();
            string query = "select book_id,cart_quantity from book_user_cart where user_id=@userid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userid", user_id);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Book temp = new Book();
                    temp.quantity = Convert.ToInt32(reader["cart_quantity"].ToString());
                    temp.bookid = (reader["book_id"].ToString());
                    cart.Add(temp);
                }
                reader.Close();
            }

            foreach (Book b in cart)
            {
                query = "select * from books where book_id=@bookid";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookid", b.bookid);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    b.author = reader["book_author"].ToString();
                    b.title = reader["book_title"].ToString();
                    b.price = Convert.ToDecimal(reader["book_price"].ToString());
                }
                reader.Close();
            }

            cart_tbl.Rows.Clear();
            if (cart.Count > 0)
            {
                int count = 0;
                TableRow tempRow = new TableRow();
                foreach (Book b in cart)
                {
                    TableCell tempCell = new TableCell();
                    tempCell.BorderWidth = 4;
                    tempCell.BorderStyle = BorderStyle.Groove;
                    tempCell.Text = "<b>" + b.title + "</b><br/>Price: $" + b.price + "<br/>Quantity: " + b.quantity;
                    tempRow.Cells.Add(tempCell);
                    count++;
                    if (count % 5 == 0)
                    {
                        cart_tbl.Rows.Add(tempRow);
                        tempRow = new TableRow();
                    }
                }
                if (count % 5 != 0)
                {
                    cart_tbl.Rows.Add(tempRow);
                }
            }
            else
            {
                TableRow tempRow = new TableRow();
                TableCell tempCell = new TableCell();
                tempCell.BorderWidth = 4;
                tempCell.BorderStyle = BorderStyle.Groove;
                tempCell.Text = "Cart is currently empty";
                tempRow.Cells.Add(tempCell);
                cart_tbl.Rows.Add(tempRow);
            }
        }
        protected void PopulateBooks()
        {
            boxes = new List<CheckBox>();
            dropList = new List<DropDownList>();
            bool inStock = false;
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);

            conn.Open();
            string query = "select * from books";
            SqlCommand cmd = new SqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                books = new List<Book>();
                while (reader.Read())
                {
                    Book temp = new Book();
                    temp.author = reader["book_author"].ToString();
                    temp.bookid = reader["book_id"].ToString();
                    temp.price = Convert.ToDecimal(reader["book_price"].ToString());
                    temp.quantity = Convert.ToInt32(reader["book_quantity"].ToString());
                    temp.title = reader["book_title"].ToString();
                    books.Add(temp);
                }
                reader.Close();
            }

            books_tbl.Rows.Clear();
            if (books.Count > 0)
            {
                int count = 0;
                TableRow tempRow = new TableRow();
                foreach (Book b in books)
                {
                    if (b.quantity > 0)
                    {
                        inStock = true;
                        TableCell tempCell = new TableCell();
                        tempCell.BorderWidth = 4;
                        tempCell.BorderStyle = BorderStyle.Groove;
                        tempCell.Text = "<b>" + b.title + "</b><br/>Price: $" + b.price + "<br/>Copies Available: "+ b.quantity + "<br/>Add to Cart";

                        CheckBox checkBox = new CheckBox();
                        checkBox.ID = "c" + b.bookid;
                        boxes.Add(checkBox);
                        ((IParserAccessor)tempCell).AddParsedSubObject(checkBox);
                        

                        DropDownList drop = new DropDownList();
                        drop.ID = "d" + b.bookid;
                        for (int i = 1; i <= b.quantity && i < 21; i++)
                        {
                            drop.Items.Add(Convert.ToString(i));
                        }
                        dropList.Add(drop);
                        ((IParserAccessor)tempCell).AddParsedSubObject(drop);

                        tempRow.Cells.Add(tempCell);
                        count++;

                        if (count % 5 == 0)
                        {
                            books_tbl.Rows.Add(tempRow);
                            tempRow = new TableRow();
                        }
                    }
                }
                if (count % 5 != 0)
                {
                    books_tbl.Rows.Add(tempRow);
                }
            }
            else if (books.Count < 1 || !inStock)
            {
                TableRow tempRow = new TableRow();
                TableCell tempCell = new TableCell();
                tempCell.BorderWidth = 4;
                tempCell.BorderStyle = BorderStyle.Groove;
                tempCell.Text = "Currently no books in stock";
                tempRow.Cells.Add(tempCell);
                cart_tbl.Rows.Add(tempRow);
            }
        }

        protected void checkout_btn_Click(object sender, EventArgs e)
        {
            int quantity;
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);
            conn.Open();
            purchase_lbl.Text = "";
            fail_lbl.Text = "";

            foreach(Book b in cart){
                string query = "select * from books where book_id=@cartbook";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cartbook", b.bookid);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    quantity = Convert.ToInt32(reader["book_quantity"].ToString());
                    if (quantity > 0 && quantity >= b.quantity)
                    {
                        purchase_lbl.Text += "Purchased " + reader["book_title"].ToString() + ", ";
                        reader.Close();
                        query = "UPDATE books SET book_quantity=@newquan WHERE book_id=@bookid";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@newquan", (quantity - b.quantity));
                        cmd.Parameters.AddWithValue("@bookid", b.bookid);
                        cmd.ExecuteNonQuery();

                        query = "DELETE FROM book_user_cart WHERE book_id=@bookid AND user_id=@userid";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@bookid", b.bookid);
                        cmd.Parameters.AddWithValue("@userid", user_id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        fail_lbl.Text += "Could not purchase " + reader["book_title"].ToString() + ", ";
                        reader.Close();
                    }
                }
            }
            conn.Close();
            PopulateCart();
            PopulateBooks();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            string query;
            string id;
            string title;
            int quantity;
            bool alreadyInCart;
            info_lbl.Text = "";
            SqlCommand cmd;
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["book_store"].ConnectionString);
            conn.Open();
            foreach (CheckBox c in boxes)
            {
                alreadyInCart = false;
                if (c.Checked)
                {
                    id = c.ID.Replace("c", "");
                    quantity = Convert.ToInt32(dropList.Find(x => x.ID.Equals("d" + id)).SelectedValue);
                    query = "select * from book_user_cart where book_id=@bookid AND user_id=@userid";
                    cmd = new SqlCommand(query,conn);
                    cmd.Parameters.AddWithValue("@bookid", id);
                    cmd.Parameters.AddWithValue("@userid",user_id);
                    reader = cmd.ExecuteReader();
                    if(reader.HasRows){
                        reader.Read();
                        quantity += Convert.ToInt32(reader["cart_quantity"].ToString());
                        alreadyInCart = true;
                    }
                    reader.Close();
                    query = "select * from books where book_id=@bookid";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bookid", id);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    title = reader["book_title"].ToString();
                    int oldQuantity = Convert.ToInt32(reader["book_quantity"].ToString());
                    if (oldQuantity >= quantity && oldQuantity > 0)
                    {
                        reader.Close();
                        if (alreadyInCart)
                        {
                            query = "UPDATE book_user_cart SET cart_quantity=@quantity where book_id=@bookid AND user_id=@userid";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@quantity", quantity);
                            cmd.Parameters.AddWithValue("@bookid", id);
                            cmd.Parameters.AddWithValue("@userid", user_id);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            query = "INSERT INTO book_user_cart (user_id, book_id, cart_quantity) VALUES (@userid, @bookid, @quantity)";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@quantity", quantity);
                            cmd.Parameters.AddWithValue("@bookid", id);
                            cmd.Parameters.AddWithValue("@userid", user_id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        info_lbl.Text += "Unable to add " + title + ", ";
                    }
                }
            }
            conn.Close();
            PopulateCart();
            PopulateBooks();
        }

        protected void logout_btn_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}