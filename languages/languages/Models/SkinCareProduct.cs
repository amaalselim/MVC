using System.ComponentModel.DataAnnotations;

namespace languages.Models
{
	public class SkinCareProduct
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
	
		public string Name { get; set; }
		[Required]
		[RegularExpression (".*\\.(jpg$|png$)",ErrorMessage ="must end with .jpg or .png")]
		public string Image { get; set; }
		[Required]

		public string Description { get; set; }

	}
}
