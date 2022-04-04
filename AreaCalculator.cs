using static System.Console;

namespace SimpleGeometry {
public class AreaCalculator {
/// <summary>
/// Вычисление площади фигуры без указания её типа
/// </summary>
/// <param name="args"> Параметры фигуры </param>
/// <returns></returns>
public string CalculateArea( double[] args )
{	string res;

	switch( args.Length )
	{	case 1:
			res = $"Площадь вашего круга = { CircleArea( args ) }.";
			break;
		case 3:
			res = $"Площадь вашего треугольника = { TriangleArea( args ) }.";
			break;

		default:
			res = "Фигуры с такими параметрами пока не поддерживаются.";
			break;
	}

	return res;
}

/// <summary>
/// Вычисление площади круга
/// </summary>
/// <param name="args"></param>
/// <returns></returns>
private double CircleArea( double[] args )
{	return Math.PI * Math.Pow( args[0], 2 );  }

/// <summary>
/// Вычисление площади треугольника
/// </summary>
/// <param name="args"></param>
/// <returns></returns>
private double TriangleArea( double[] args )
{	double p, s;

	p = ( args[ 0 ] + args[ 1 ] + args[ 2 ] ) / 2;	

	if( IsRight( args, out double catets ) )
		s = catets / 2; else
		s = Math.Sqrt( p * ( p - args[ 0 ] ) * ( p - args[ 1 ] ) * ( p - args[ 2 ] ) );

	return s;
}

/// <summary>
/// Проверка треугольника на прямоугольность
/// </summary>
/// <param name="sides">Размеры сторон</param>
/// <param name="catSum">Сумма катетов</param>
/// <returns></returns>
static private bool IsRight( double[] sides, out double catSum )
{	double a = sides[ 0 ];
	double b = sides[ 1 ];
	double c = sides[ 2 ];

	if( Math.Pow( a, 2 ) + Math.Pow( b, 2 ) == Math.Pow( c, 2 ) )
		catSum = a + b;
	else if( Math.Pow( a, 2 ) + Math.Pow( c, 2 ) == Math.Pow( b, 2 ) )
		catSum = a + c;
	else if( Math.Pow( b, 2 ) + Math.Pow( c, 2 ) == Math.Pow( a, 2 ) )
		catSum = b + c;
	else
		catSum = -1;

	if( catSum != -1 ) 
		WriteLine( "Треугольник прямоугольный." ); else
		WriteLine( "Треугольник не прямоугольный." );

	return catSum != -1;
}

}}