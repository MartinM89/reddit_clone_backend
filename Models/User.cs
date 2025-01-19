using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    [MaxLength(255)]
    public string Email { get; set; } = default!;

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Surname { get; set; } = default!;

    [Required]
    [MaxLength(255)]
    public string Adress { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = default!;

    [Required]
    [MaxLength(20)]
    public string ZipCode { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = default!;

    [Required]
    [MaxLength(20)]
    public string SocialSecurityNumber { get; set; } = default!;

    [Required]
    public bool IsAdmin { get; set; }

    // public ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public User(
        string email,
        string passwordHash,
        string firstName,
        string surname,
        string adress,
        string city,
        string zipCode,
        string country,
        string socialSecurityNumber,
        bool isAdmin
    )
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        Surname = surname;
        Adress = adress;
        City = city;
        ZipCode = zipCode;
        Country = country;
        SocialSecurityNumber = socialSecurityNumber;
        IsAdmin = isAdmin;
    }

    // Empty constructor for EF
    public User() { }
}
