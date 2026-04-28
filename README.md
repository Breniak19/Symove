Symove 🚀

Symove es una herramienta desarrollada en C# (Windows Forms) diseñada no solo para mover carpetas y archivos pesados (como juegos o programas de la unidad C:) a otro disco duro creando automáticamente un enlace simbólico, sino también para gestionar, escanear y revertir dichos enlaces.

De esta manera, el sistema operativo y las aplicaciones seguirán creyendo que los archivos están en su ubicación original, pero el espacio físico se ocupará en el disco de destino. ¡Ideal para liberar espacio en unidades SSD de poca capacidad y mantener tu sistema limpio de enlaces huérfanos!

✨ Características Principales

Procesamiento por Lotes (Batch Mode): Selecciona múltiples carpetas y/o archivos al mismo tiempo para moverlos y enlazarlos en una sola operación.

Gestor y Escáner de Enlaces: Escanea directorios completos en busca de enlaces simbólicos (ReparsePoints) creados previamente.

Detección de Enlaces Rotos: Identifica inteligentemente si los archivos del "Destino Real" han sido borrados, marcando el enlace como "Roto" (huérfano) en color rojo para que puedas limpiar tu disco.

Reversión Segura (Undo): ¿Te arrepentiste de mover un juego? Con un solo clic puedes deshacer el enlace. Symove eliminará el enlace simbólico y moverá los archivos de vuelta a su ubicación original de forma totalmente segura.

Manejo Seguro de Datos: * Usa Robocopy (con reintentos en caso de errores) para mover carpetas pesadas de forma robusta, tanto de ida como de vuelta.

Usa copiado y borrado seguro para archivos individuales.

Registro de Actividad Centralizado (Logs): Genera automáticamente un archivo Symove_Log.txt en la misma ruta del ejecutable. Este log guarda un historial detallado de todo lo que se crea y se revierte.

Interfaz de Usuario: Un diseño limpio en "Modo Oscuro" dividido en pestañas intuitivas.

⚠️ Requisitos Previos

Para que Symove pueda crear enlaces simbólicos mediante el comando mklink de Windows, es estrictamente necesario ejecutar la aplicación como Administrador.

Sistema Operativo: Windows 10 / 11.

Framework: .NET 8.0 (o superior).

🛠️ Cómo usarlo

1️⃣ Crear Enlaces (Mover archivos al nuevo disco)

Abre el programa como Administrador.

En la pestaña Crear Enlaces, usa los botones "+ Carpeta" o "+ Archivos" para añadir los elementos que deseas mover.

Haz clic en "Examinar" para elegir la Carpeta Destino Raíz (ej. D:\JuegosMovidos).

Presiona el botón azul "MOVER Y CREAR ENLACE(S)".

2️⃣ Gestionar Enlaces (Escanear y Deshacer)

Ve a la pestaña Gestionar Enlaces.

Haz clic en "Examinar" y elige la carpeta base que deseas escanear (ej. C:\Program Files o C:\Juegos).

Haz clic en "Escanear". (Puedes marcar la casilla de "Mostrar solo enlaces rotos" si solo quieres hacer limpieza).

Para revertir un proceso, selecciona uno o varios enlaces de la lista y presiona el botón rojo "DESHACER ENLACE(S) SELECCIONADO(S)".

⚙️ ¿Cómo funciona bajo el capó?

Al Crear: El programa invoca robocopy de forma oculta usando los parámetros /E /MOVE /R:1 /W:1 para garantizar un traslado perfecto. Luego de verificar el código de salida, ejecuta cmd.exe /c mklink /D para crear el directorio enlazado.

Al Deshacer (Undo): Primero verifica que la data real todavía exista. Si es así, elimina el enlace simbólico (el acceso directo falso) y vuelve a ejecutar robocopy para mover la data original desde el disco secundario de vuelta al disco principal.

📝 Registro de Eventos (Log)

Ejemplo de cómo se ve el archivo de registro generado (Symove_Log.txt):

[2023-10-27 14:30:00] --- INICIO DE BATCH (CREACIÓN) ---
[ÉXITO] Movido y enlazado: C:\Juegos\JuegoPesado -> D:\NuevosJuegos\JuegoPesado
[2023-10-27 14:31:45] --- FIN DE BATCH (Éxito: 1, Fallos: 0) ---

[2023-10-28 09:15:00] --- INICIO DE REVERSIÓN (UNDO) ---
[ÉXITO REVERSIÓN] Enlace eliminado y restaurado de: D:\NuevosJuegos\JuegoPesado -> C:\Juegos\JuegoPesado
[2023-10-28 09:16:30] --- FIN DE REVERSIÓN (Éxito: 1, Fallos: 0) ---


👨‍💻 Autor

Creado por Breniak.
