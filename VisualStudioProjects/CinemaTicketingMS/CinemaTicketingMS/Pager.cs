using System;
using System.Data;
using System.Data.SqlClient;

namespace CinemaTicketingMS
{
    //分页
    [Serializable]
    public class Pager
    {
        public int PageIndex { get; set; }//页码
        public int PageSize { get; set; }//每页记录数
        public int PageCount { get; set; }//总页数
        public int Count { get; set; }//数据记录总数

        public Pager()
        {
            this.PageSize = 10;
            this.PageIndex = 1;

            SqlParameter[] paras = new SqlParameter[4];
            paras[0] = new SqlParameter("@pageIndex",SqlDbType.Int);
            paras[0].Value = this.PageIndex;
            paras[1] = new SqlParameter("@pageSize", SqlDbType.Int);
            paras[1].Value = this.PageSize;

            paras[2] = new SqlParameter("@pageCount", SqlDbType.Int);
            paras[2].Direction = ParameterDirection.Output;
            paras[3] = new SqlParameter("@count", SqlDbType.Int);
            paras[3].Direction = ParameterDirection.Output;


            SqlDataReader dr=DBHelperSQL.GetDataReaderByProc("proc_pager", paras);
            //只能写取表的代码
            //1、表数据的获取必须在close前
            dr.Close();
            //2、输出参数的获取必须在close之后
            this.PageCount = (int)paras[2].Value;
            this.Count = (int)paras[3].Value;
        }
        //是否为首页
        public bool IsFirst()
        {
            return this.PageIndex - 1 <= 1;
        }
        //是否为尾页
        public bool IsLast()
        {
            return this.PageIndex >= this.PageCount;
        }
        //首页
        public void FirstPage()
        {
            this.PageIndex = 1;
        }
        //上一页
        public void PrevPage()
        {
            if (this.IsFirst())
            {
                this.PageIndex = 1;
            }
            else
            {
                this.PageIndex--;
            }
        }
        //下一页
        public void NextPage()
        {
            if (this.IsLast())
            {
                this.PageIndex = this.PageCount;
            }
            else
            {
                this.PageIndex++;
            }
        }
        //尾页
        public void LastPage()
        {
            this.PageIndex = this.PageCount;
        }
        //指定页
        public bool ToPage(int a)
        {
            if (a>=1 && a<=PageCount)
            {
                this.PageIndex = a;
                return true;
            }
            return false;
        }
    }
}