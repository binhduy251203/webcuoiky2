namespace webcuoiky2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        public int SoDonHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDatHang { get; set; }

        public decimal TriGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGiao { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNguoiNhan { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChiNhan { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoaiNhan { get; set; }

        [Required]
        [StringLength(50)]
        public string HinhThucThanhToan { get; set; }

        [Required]
        [StringLength(50)]
        public string HinhThucGiaoHang { get; set; }

        public int MaKhach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
