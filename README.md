Examen Práctico Tercer Parcial: Sistema de Gestión de Registros Académicos en C#
Equipo de Desarrollo

- Miguel Francisco Cortés Álvarez
- Emmanuel de la Cruz
- Alejandro Guzmán Cabrales
- Laura Georgina Ruiz Campos

📖 Descripción General

Este proyecto en C# es una aplicación de consola diseñada para gestionar registros académicos de estudiantes en una institución educativa.
Utiliza estructuras de datos eficientes y diferentes algoritmos de búsqueda y ordenamiento para maximizar el rendimiento y facilitar las operaciones de consulta y registro de datos académicos.

🛠️ Tecnologías y Estructuras Utilizadas

- .NET 6.0+
- C# 10
- Estructura lineal: List<Student>
- Estructura no lineal: Árbol Binario de Búsqueda Genérico (BST<TKey, TData>)
- Algoritmo de Ordenamiento: QuickSort
- Algoritmos de Búsqueda:
  1. Búsqueda en Árbol Binario (por matrícula y por nombre)
  2. Búsqueda Binaria (en lista ordenada)
  3. Búsqueda Secuencial (en lista desordenada)

🚀 Funcionalidades Principales

- Agregar Estudiante: Permite registrar nuevos estudiantes validando nombre, matrícula (única) y promedio. Verifica errores de entrada y evita duplicados.
- Ordenamiento: Se implementa QuickSort para organizar los estudiantes por matrícula, con eficiencia O(n·log n) en promedio.
- Búsqueda: 
  * BST: Eficiente en promedio con O(log n).
  * Binaria: Rápida en listas ordenadas.
  * Secuencial: Método de respaldo en caso de listas desordenadas.
- Pruebas de Eficiencia: Mide los tiempos de ejecución al insertar 1,000 y 10,000 estudiantes, ordenarlos y buscarlos.
- Manejo de Errores: Validación robusta de entradas de usuario, incluyendo detección de campos vacíos y formatos incorrectos.

🧪 Pruebas de Manejo de Errores
Ejemplo de pruebas con xUnit para validar entradas incorrectas:

[Fact]
public void AddStudent_InvalidAverage_UsesZero()
{
    var input = new StringReader("Juan\nM123\nabc\n");
    Console.SetIn(input);
    var output = new StringWriter();
    Console.SetOut(output);

    Program.AddStudent();

    string log = output.ToString();
    Assert.Contains("Entrada de promedio inválida. Usando 0.", log);
}


[Fact]
public void AddStudent_EmptyName_ShowsError()
{
    var input = new StringReader("\nM123\n8.5\n");
    Console.SetIn(input);
    var output = new StringWriter();
    Console.SetOut(output);

    Program.AddStudent();

    string log = output.ToString();
    Assert.Contains("Nombre o matrícula inválidos.", log);
}

📦 Instalación y Uso

1. Clona el repositorio:
   git clone https://github.com/tuusuario/StudentManagementSystem.git
2. Navega al directorio:
   cd StudentManagementSystem
3. Compila el proyecto:
   dotnet build
4. Ejecuta la aplicación:
   dotnet run

🔍 Detalles del Código y Futuras Mejoras

Este sistema tiene una arquitectura modular, donde cada archivo tiene una responsabilidad clara:

- `estudiantes.cs`: Modelo de datos con propiedades como nombre, matrícula y promedio.
- `BST.cs`: Implementa un Árbol Binario de Búsqueda genérico para búsquedas eficientes.
- `SearchOperations.cs`: Contiene funciones para búsqueda secuencial y binaria.
- `StudentOperations.cs`: Lógica de negocio para agregar estudiantes, validaciones y control general.
- `EfficiencyTests.cs`: Pruebas de rendimiento para distintas operaciones.
- `Program.cs`: Interfaz de usuario (menú principal) y flujo de ejecución.

Futuras mejoras podrían incluir:
- Guardar y cargar datos desde archivos.
- Interfaz gráfica con WinForms o WPF.
- Integración con bases de datos.
- Uso de LINQ para consultas más potentes.
- Exportación de reportes académicos a PDF.

Este proyecto es una base sólida para construir un sistema académico completo con funcionalidades escalables.

