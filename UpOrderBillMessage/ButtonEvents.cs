using System;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Core.List.PlugIn;

namespace UpOrderBillMessage
{
    public class ButtonEvents : AbstractListPlugIn
    {
        public override void BarItemClick(BarItemClickEventArgs e)
        {
            var generate = new Generate();

            //定义主键变量(用与收集所选中的行主键值)
            var flistid = string.Empty;

            base.BarItemClick(e);

            if (e.BarItemKey == "tbUpOrderBillMess")
            {
                //获取列表上通过复选框勾选的记录
                var selectedrows = this.ListView.SelectedRowsInfo;
                //通过循环将选中行的主键进行收集
                foreach (var row in selectedrows)
                {
                    if (string.IsNullOrEmpty(flistid))
                    {
                        flistid = "'" + Convert.ToString(row.PrimaryKeyValue) + "'";
                    }
                    else
                    {
                        flistid += "," + "'" + Convert.ToString(row.PrimaryKeyValue) + "'";
                    }
                }
                //根据所获取的单号进行更新
                generate.UpOrderMessage(flistid);

                //输出
                View.ShowMessage("已完成更新开票信息操作.");
            }
        }
    }
}
