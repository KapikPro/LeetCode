using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text;

using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

Stopwatch a = new Stopwatch();
a.Start();
int quantity = int.Parse(input.ReadLine()??"0");
for (int i = 0; i < quantity; i++)
{
  int n = int.Parse(input.ReadLine()??"0");
  List<int> arrival = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
  List<Product> products = new List<Product>();
  for (int k = 0; k < arrival.Count; k++)
    products.Add(new Product(k, arrival[k]));
  products = products.OrderBy(x => x.arrival).ToList();
  int prod_num = 0;
  
  int m = int.Parse(input.ReadLine()??"0");
  List<Car> cars =new List<Car>();
  int car_num = 0;
  
  List<int> line = new List<int>();
  for (int j = 0; j < m; j++)
  {
    line = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
    cars.Add(new Car(j,line[0],line[1],line[2]));
  }
  cars = cars.OrderBy(x => x.start).ToList();
  
  while(prod_num != n)
  {
    Solution(products, cars,ref car_num, ref prod_num);
  }
  products = products.OrderBy(x => x.n).ToList();
  for (int j = 0; j < n; j++)
  {
    output.Write(products[j].car_num+" ");
  }
  output.Write('\n');
}

void Solution(List<Product> products, List<Car> cars, ref int car_num, ref int prod_num)
{
  if (car_num == cars.Count)
  {
    prod_num++;
    return;
  }
  if (products[prod_num].arrival <= cars[car_num].start || (products[prod_num].arrival > cars[car_num].start && products[prod_num].arrival < cars[car_num].end))
  {
    if (cars[car_num].current_capacity == cars[car_num].capacity)
    {
      car_num++;
      return;
    }
    cars[car_num].current_capacity++;
    prod_num++;
    products[prod_num-1].car_num= car_num + 1;
  }
  else
  {
    car_num++;
  }
}
class Car
{
  public int m;
  public int start;
  public int end;
  public int capacity;
  public int current_capacity = 0 ;

  public Car(int _m, int _start, int _end, int _capacity)
  {
    m = _m;
    start = _start;
    end = _end;
    capacity = _capacity;
  }
}

class Product
{
  public int n;
  public int arrival;
  public int car_num = -1;
  public Product(int _n, int _arrival)
  {
    n = _n;
    arrival = _arrival;
  }
}