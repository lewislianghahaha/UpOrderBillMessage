namespace UpOrderBillMessage
{
    public class SqlList
    {
        private string _result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public string GetUpdate(string listid)
        {
            _result = $@"
                            UPDATE A SET A.F_YTC_TEXT41=X.开票信息名称
                            FROM dbo.T_BD_CUSTOMER A
                            INNER JOIN (
				                            SELECT  TOP 1 B.F_YTC_BASE 客户ID,B.F_YTC_TEXT1 开票信息名称
				                            FROM dbo.ytc_t_Cust100018 B   
				                            ORDER BY B.FID DESC
                                       )X ON A.FCUSTID=X.客户ID
                            WHERE A.FCUSTID IN ({listid})
                        ";

            return _result;
        }

    }
}
