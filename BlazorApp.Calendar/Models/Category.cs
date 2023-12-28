using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Calendar.Models
{
  [Table("Categories")]
  public partial class Category
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID
    {
      get;
      set;
    }


    [InverseProperty("Category")]
    public ICollection<Product> Products { get; set; }
    public string CategoryName
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public string Picture
    {
      get;
      set;
    }
  }
}
