Sistema de Gestión para Parque Tecnológico Innovatec

Descripción
Sistema desarrollado en C# que administra la jerarquía organizativa mediante árboles y modela las rutas internas entre edificios utilizando grafos. Este proyecto fue desarrollado como caso de estudio para la Universidad Americana (UAM).

Funcionalidades

Parte A: Arbol - Jerarquía Organizativa
- Registro de jerarquía: Estructura de árbol general para representar la organización
- Operaciones del árbol:
  - Inserción de nodos hijos
  - Búsqueda de nodos por nombre
  - Conteo total de nodos
  - Cálculo de niveles organizativos
  - Recorrido en preorden con formato jerárquico

Parte B: Grafo - Sistema de Rutas del Parque
- Representación de conexiones**: Grafo no dirigido y ponderado
- Operaciones del grafo:
  - Registro de edificios (nodos)
  - Conexiones entre edificios con distancias
  - Validación de grafo conexo
  - Cálculo de ruta más corta (algoritmo Dijkstra)
  - Visualización de conexiones específicas

Tecnologías Utilizadas
- C# .NET
- Windows Forms
- Algoritmos de grafos (Dijkstra, BFS)
- Estructuras de datos: Árbol general, Grafo no dirigido

Estructura del Proyecto

```
ArbolesYGrafos/
├── Properties/              # Configuración del proyecto
├── Referencias/            # Referencias de ensamblados
├── App.config              # Configuración de la aplicación
├── Form1.cs                # Interfaz de usuario principal
├── Form1.Designer.cs       # Diseño de la interfaz
├── Form1.resx              # Recursos del formulario
├── Graph.cs                # Clase del grafo no dirigido ponderado
├── OrgTree.cs              # Clase del árbol organizativo
├── Program.cs              # Punto de entrada de la aplicación
└── README.md               # Este archivo
```

Archivos Principales

Form1.cs
Interfaz de usuario principal que gestiona la interacción con el árbol organizativo y el grafo de rutas.

OrgTree.cs
Implementa un árbol general con operaciones para gestión de la jerarquía organizativa. Contiene las clases:
- `TreeNode`: Representa un nodo en la jerarquía organizativa
- `OrgTree`: Implementa las operaciones del árbol

Graph.cs
Representa un grafo no dirigido y ponderado para modelar las rutas entre edificios. Contiene las clases:
- `Graph`: Implementa el grafo y sus algoritmos
- `DijkstraResult`: Almacena resultados del algoritmo de rutas más cortas

Program.cs
Punto de entrada principal de la aplicación Windows Forms.

Algoritmos Implementados

Para el Árbol
- Búsqueda en profundidad (DFS) para localizar nodos
- Recorrido en preorden para visualización jerárquica
- Cálculo recursivo de niveles y conteos

Para el Grafo
- Algoritmo Dijkstra para rutas más cortas
- Búsqueda en amplitud (BFS) para validar conexidad
- Representación mediante lista de adyacencia

#Instalación y Ejecución

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Compilar el proyecto
4. Ejecutar la aplicación

Uso del Sistema

Gestión del Árbol Organizativo
1. Agregar nodos hijos especificando el padre
2. Buscar nodos por nombre
3. Contar el total de elementos organizativos
4. Calcular niveles jerárquicos
5. Visualizar la estructura completa

Gestión del Grafo de Rutas
1. Registrar edificios individualmente
2. Establecer conexiones entre edificios con distancias
3. Validar si todos los edificios están conectados
4. Calcular rutas más cortas entre cualquier par de edificios
5. Consultar conexiones específicas de cada edificio

Requisitos del Sistema
- .NET Framework 4.7.2 o superior
- Visual Studio 2019 o superior
- Sistema operativo Windows

Características Técnicas

- Interfaz gráfica intuitiva con Windows Forms
- Validación de datos de entrada
- Manejo de excepciones
- Algoritmos optimizados para grafos de tamaño moderado
- Estructuras de datos eficientes para las operaciones requeridas

Desarrollado para
Universidad Americana (UAM) - Caso de Estudio: Arboles y Grafos en C#
