namespace webcuoiky2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        [Key]
        public int MaKhach { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên Khách")]
        public string TenKhach { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Giới Tính")]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}
