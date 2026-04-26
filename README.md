Symove 🚀

Symove es una herramienta desarrollada en C# (Windows Forms) diseñada para mover carpetas y archivos pesados (como juegos o programas de la unidad C:) a otro disco duro, creando automáticamente un enlace simbólico en la ruta original.

De esta manera, el sistema operativo y las aplicaciones seguirán creyendo que los archivos están en su ubicación original, pero el espacio físico se ocupará en el disco de destino. ¡Ideal para liberar espacio en unidades SSD de poca capacidad!

✨ Características

Procesamiento por Lotes (Batch Mode): Selecciona múltiples carpetas y/o archivos al mismo tiempo para moverlos y enlazarlos en una sola operación.

Soporte para Archivos y Carpetas: Identifica inteligentemente qué elementos son carpetas y cuáles son archivos, aplicando el método correcto de movimiento y enlace para cada uno.

Manejo Seguro de Datos: * Usa Robocopy (con reintentos en caso de errores) para mover carpetas pesadas de forma robusta.

Usa copiado y borrado seguro para archivos individuales.

Registro de Actividad (Logs): Genera automáticamente un archivo Symove_Log.txt en la misma ruta del ejecutable. Este log guarda un historial detallado con fechas, horas y el estado (éxito o error) de cada elemento procesado.

Interfaz de Usuario: Un diseño limpio en "Modo Oscuro" que es fácil e intuitivo de usar.

⚠️ Requisitos Previos

Para que Symove pueda crear enlaces simbólicos mediante el comando mklink de Windows, es estrictamente necesario ejecutar la aplicación como Administrador.

Sistema Operativo: Windows 10 / 11.

Framework: .NET Framework / .NET Core (Dependiendo de tu configuración de compilación).

🛠️ Cómo usarlo

Abre el programa como Administrador (Clic derecho > Ejecutar como Administrador).

Usa los botones "+ Carpeta" o "+ Archivos" para añadir los elementos que deseas mover a la lista de Origen.

Haz clic en "Examinar" para elegir la Carpeta Destino Raíz (ej. D:\JuegosMovidos).

Presiona el botón azul "MOVER Y CREAR ENLACE(S)".

Espera a que el proceso termine. Puedes revisar el archivo Symove_Log.txt para confirmar que todo se movió correctamente.

⚙️ ¿Cómo funciona bajo el capó?

Para Carpetas: El programa invoca robocopy de forma oculta usando los parámetros /E /MOVE /R:1 /W:1 para garantizar un traslado perfecto. Luego de verificar el código de salida, ejecuta cmd.exe /c mklink /D para crear el directorio enlazado.

Para Archivos: Mueve el archivo asegurando que el directorio destino exista y luego ejecuta cmd.exe /c mklink (sin el flag /D) para enlazar el archivo.

📝 Registro de Eventos (Log)

Ejemplo de cómo se ve el archivo de registro generado (Symove_Log.txt):

[2023-10-27 14:30:00] --- INICIO DE BATCH ---
[ÉXITO] Movido y enlazado: C:\Juegos\JuegoPesado -> D:\NuevosJuegos\JuegoPesado
[ÉXITO] Movido y enlazado: C:\Docs\Archivo.txt -> D:\NuevosJuegos\Archivo.txt
[2023-10-27 14:31:45] --- FIN DE BATCH (Éxito: 2, Fallos: 0) ---


👨‍💻 Autor

Creado por Breniak.
