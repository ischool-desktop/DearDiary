using FISCA.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearDiaryAdmin
{
    [TableName("diary_record")]
    class DiaryRecord : ActiveRecord
    {
        [Field(Field = "ref_student_id", Indexed = true)]
        public int RefStudentID { get; set; }
        [Field(Field = "content", Indexed = false)]
        public string Content { get; set; }
    }
}
