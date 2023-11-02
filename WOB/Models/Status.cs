using System.ComponentModel.DataAnnotations;

namespace WOB.Models
{
    /// <summary>
    /// 健康状態を保存するマスタテーブル
    /// </summary>
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusCode { get; set; }
    }
}
