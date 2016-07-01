using System;
using System.Collections.Generic;
using System.Linq;
using FISCA;

namespace DearDiaryAdmin
{
    public static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [MainMethod]
        public static void Main()
        {
            K12.Presentation.NLDPanels.Student.RibbonBarItems["DearDiary"]["addTestData"].Click += delegate
            {
                //取得選取學生
                var stuList = K12.Data.Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource);
                //多次儲存
                foreach (var stuRec in stuList)
                {
                    var newRec = new DiaryRecord()
                    {
                        RefStudentID = int.Parse(stuRec.ID),
                        Content = "TEST"
                    };
                    newRec.Save();
                }
                return;
                //批次儲存
                List<DiaryRecord> list = new List<DiaryRecord>();
                foreach (var stuRec in stuList)
                {
                    list.Add(new DiaryRecord()
                    {
                        RefStudentID = int.Parse(stuRec.ID),
                        Content = "TEST"
                    });
                }
                list.SaveAll();

            };
            K12.Presentation.NLDPanels.Student.RibbonBarItems["DearDiary"]["showDiaryCount"].Click += delegate
            {
                var stuList = K12.Data.Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource);
                var message = "";
                foreach (var stuRec in stuList)
                {
                    FISCA.UDT.AccessHelper accessHelper = new FISCA.UDT.AccessHelper();
                    message += string.Format("{0}:{1}\n", stuRec.Name, accessHelper.Select<DiaryRecord>("ref_student_id=" + stuRec.ID).Count);
                }
                System.Windows.Forms.MessageBox.Show(message.TrimEnd());
            };
        }
    }
}
