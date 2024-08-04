Implementasi enkapsulasi dapat terlihat pada properti tiap Model diset menjadi Private sehingga class lain tidak bisa mengakses langsung model tersebut.
Untuk mengakses properti model tersebut harus menggunakan metode yang sudah tersedia pada class tersebut, dapat dicontohkan pada class Food.
 public class Dessert : MenuItem {
    private int SugarLevel;
    public Dessert(string name, string description, int basePrice, int SugarLevel) 
        : base(name, description, basePrice) {
        this.SugarLevel = SugarLevel;
    }
    public int GetSugarLevel(){
        return SugarLevel;
    }
    public override int CalculatePrice()
    {
       int price = Price + 1000*SugarLevel;
       return price;
    }
    }
pada class food, untuk mendapatkan nilai sugarLevel, harus melalui metode GetSugarLevel.

Implementasi Inheritance terdapat pada class Food, Beverage, dan Dessert yang berinduk pada class MenuItem.
Dapat dilihat pada contoh class Desert di atas, untuk implementasi inheritance ditulis dengan titik dua :
public class Dessert : MenuItem
Ini menunjukan bahwa properti pada class MenuItem seperti name, string, description, juga dimiliki oleh class Desert, Food, dan Beverage.

Implementasi polymorphism juga dilakukan oleh class Food,Beverage,dan Dessert yaitu pada metode CalculatePrice. Class MenuItem adalah abstract class
yang memiliki metode CalculatePrice() dimana metode ini harus diimplementasikan oleh derived class dari MenuItem yaitu class Food, Desert, dan Beverage.
Dengan melakukan ini, maka metode CalculatePrice bisa diimplementasikan sesuai dengan keadaan class tersebut. Terlihat untuk Food, implementasi CalculatePrice
mengaitkan properti Spiciness, untuk Dessert SugarLevel, dan Beverage adalah Size.
public override int CalculatePrice()
    {
       int price = Price + 1000*SugarLevel;
       return price;
    }
di atas ini merupakan implementasi dari polymorphism pada metode CalculatePrice() pada class Dessert, penulisan sintaks ditandai dengan public override int CalculatePrice()

Untuk Implementasi Abstraksi terdapat pada Class MenuItem, dimana terdapat metode CalculatePrice. Penulisan sintaks sebagai berikut:
public abstract class MenuItem {
    private string name;
    private string description;
    private int price;

    public MenuItem(string name, string description,int price) {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public string Description {
        get { return description; }
        set { description = value; }
    }

    public int Price {
        get { return price; }
        set { price = value; }
    }
    public abstract int CalculatePrice();
    }
Dimulai dari penulisan public abstract class MenuItem dan terdapat metode yang nantinya akan diimplementasikan oleh derived classnya yaitu:
public abstract int CalculatePrice();
Ini memudahkan dalam pengembangan code dan acuan code untuk nantinya apabila ada class lain yang akan menjadi derived class dari class MenuItem seperti
Dessert, Food, dan Beverage. Dengan penggunaan abstract juga, derived class juga bisa implementasi methodnya dengan sekehendaknya sendiri tanpa terikat dari class manapun.
Dapat terlihat pada code, class Desert implementasi method CalculatePrice menggunakan properti Spiciness, Beverage dengan propert Size, dan Dessert dengan properti SugarLevel.
Sehingga dapat terlihat pada class Restaurant dimana terdapat properti Menu:
public class Restaurant {
    private string name;
    public Restaurant (string name){
        this.name = name;
    }
    private List<MenuItem> Menu = new List<MenuItem>();
    private List<Order> Orders = new List<Order>();
    public string Name {
        get { return name; }
        set { name = value; }
    }
}
Dimana pada Menu bisa terlihat ia menerima data berupa class MenuItem yang merupakan induk class dari class Food, Beverage, dan Dessert. Tentu ketiga class tersebut
dapat dimasukkan ke dalam properti Menu ini. Kalau semisal tidak ada MenuItem ini, maka class harus didefine satu-satu dan ini akan merusak salah satu SOLID principle yaitu O.
apabila terdapat class Food, ktia tambah MenuFood, kalau class Beverage tambah MenuBeverage. Daripada melakukan itu lebih baik membuat class MenuItem abstract sehingga pada class Restaurant
tidak akan terubah-ubah lagi codenya.

