# EtiquetasPrensa

Sistema de gestión e impresión de etiquetas para el área de prensa.

## Descripción

EtiquetasPrensa es una aplicación Windows Forms desarrollada en Visual Basic .NET que permite gestionar la impresión de etiquetas de identificación para sacos y pallets en el proceso de prensa. El sistema incluye lectura de códigos TAG mediante puerto serie, generación de códigos QR y gestión de datos en tiempo real.

## Características Principales

- **Gestión de TAGs**: Alta y lectura de códigos TAG para identificación de sacos
- **Impresión dual**: Soporte para dos impresoras Godex (derecha e izquierda)
- **Códigos QR**: Generación y lectura de códigos QR para trazabilidad
- **Marcador horario**: Control de tiempos y turnos de producción
- **Soporte multiidioma**: Etiquetas disponibles en:
  - Español
  - Inglés
  - Francés
  - Alemán
  - Holandés
  - Italiano
- **Integración con base de datos**: Conexión a SQL Server para gestión de datos
- **Captura de video**: Funcionalidad de captura mediante cámara (AForge.Video)
- **Impresión desde memoria**: Reimpresión de etiquetas previamente generadas

## Requisitos del Sistema

### Software
- Windows 7 o superior
- .NET Framework 4.5
- SQL Server (conexión a ServerSala)
- Visual Studio 2017 o superior (para desarrollo)

### Hardware
- Impresoras Godex DT2 (dos unidades)
- Lectores TAG con conexión por puerto serie
- Puertos USB disponibles para impresoras

### Dependencias
- **Telerik UI for WinForms R1 2019**: Componentes de interfaz de usuario
- **AForge.Video**: Captura y procesamiento de video
- **MessagingToolkit.QRCode**: Generación de códigos QR
- **ZXing**: Lectura de códigos de barras y QR
- **ControlesFrancesc**: Librería de controles personalizados

## Instalación

### 1. Instalación de Impresoras Godex

Sigue las instrucciones del archivo `InstalacionImpresoraGodexPrensa.txt`:

1. Ejecutar `\\Pc-francesc\D\Download\Softwares\Golabel\setup.exe`
2. Conectar impresora derecha al puerto USB
3. Instalar driver desde `\\Pc-francesc\D\Download\Drivers\Driver-Other`
4. Renombrar la impresora a "GodexDerecha"
5. Repetir el proceso para la impresora izquierda y renombrar a "GodexIzquierda"

### 2. Configuración de Archivos de Sistema

Copiar los siguientes archivos a sus ubicaciones:
- `GodexDerecha.bat` → `C:\`
- `GodexIzquierda.bat` → `C:\`
- `lbPrensa.ezpx` y plantillas → Carpeta de documentos del usuario
- Archivos de imagen BMP → Directorio de la aplicación

### 3. Despliegue de la Aplicación

La aplicación está configurada para desplegarse desde:
```
\\SERVERN\AppSala\EtiquetasPrensaTAG\
```

Ejecutar `setup.exe` para instalar o actualizar la aplicación.

## Estructura del Proyecto

```
EtiquetasPrensa_4/
│
├── EtiquetasPrensa/              # Proyecto principal
│   ├── Controller/               # Controladores
│   │   └── Grafica.vb           # Gestión de gráficos
│   ├── Model/                    # Modelos de datos
│   │   ├── DatosSacoModel.vb    # Modelo de datos de saco
│   │   └── DatosSacoTagModel.vb # Modelo de datos TAG
│   ├── AltaTAG.vb               # Formulario principal de alta de TAGs
│   ├── ImpresionDesdeMemoria.vb # Reimpresión de etiquetas
│   ├── MarcadorHorario.vb       # Control de turnos y horarios
│   ├── Repositorio.vb           # Acceso a datos
│   └── ChecksumHelp.vb          # Utilidades de validación
│
├── *.bmp                         # Plantillas de etiquetas multiidioma
├── *.ezpx                        # Plantillas de impresión Godex
├── *.bat                         # Scripts de configuración
└── DimensionEtiquetaHorizontal.xlsx # Especificaciones de etiquetas
```

## Configuración

### Base de Datos
El sistema se conecta a SQL Server en el servidor `ServerSala`. Asegúrate de tener:
- Permisos de conexión a la base de datos
- Acceso a la red de la sala de producción

### Puertos Serie
Configurar los puertos COM para los lectores TAG:
- Lector TAG Derecha: Configurado en la aplicación
- Lector TAG Izquierda: Configurado en la aplicación

### Rutas de Recursos
La aplicación busca imágenes de logos en:
```
\\Serversala\SIE\Img\
```

## Uso

### Alta de TAG

1. Iniciar la aplicación
2. Introducir o escanear el código de pedido
3. Leer el TAG mediante el lector correspondiente (derecha/izquierda)
4. El sistema genera automáticamente la etiqueta con:
   - Código QR
   - Información del artículo
   - Número de pallet
   - Metros/cantidad
   - Datos de trazabilidad

### Impresión

Las etiquetas se imprimen automáticamente en la impresora correspondiente según el lado (derecha/izquierda) del que proviene el TAG.

### Reimpresión

Usar el módulo "Impresión desde Memoria" para reimprimir etiquetas previamente generadas.

## Desarrollo

### Compilación

```bash
# Abrir la solución en Visual Studio
EtiquetasPrensa.sln

# Compilar en modo Release
Build > Build Solution
```

### Configuración de Build
- Plataforma: x86
- Framework: .NET Framework 4.5
- Tipo de salida: Aplicación Windows (WinExe)

## Mantenimiento

### Versiones
- Versión mínima requerida: 1.0.0.73
- Revisión actual: 177
- Actualización: Configurada para actualizarse automáticamente desde la red

### Logs y Errores
Revisar los archivos:
- `Resultados-Compilar.txt`: Resultados de compilación
- `acad.err`: Errores de AutoCAD (si aplica)

## Soporte Técnico

Para problemas con:
- **Impresoras**: Verificar conexión USB y drivers instalados
- **Lectores TAG**: Verificar puertos COM en el administrador de dispositivos
- **Base de datos**: Verificar conectividad de red con ServerSala
- **Plantillas**: Verificar que los archivos .ezpx estén en la ubicación correcta

## Notas de Seguridad

- La aplicación requiere permisos de administrador para la instalación
- Usar certificados de confianza para el despliegue
- Mantener actualizados los drivers de las impresoras
- Realizar backups periódicos de las plantillas de etiquetas

## Licencia

Uso interno de la organización.

## Contacto

Para más información o soporte, contactar con el departamento de IT.
