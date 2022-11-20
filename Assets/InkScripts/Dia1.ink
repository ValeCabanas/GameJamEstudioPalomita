EXTERNAL Name(charName)
EXTERNAL Icon(iconName)
EXTERNAL Font(fontName)
EXTERNAL Background(backgroundImage)
EXTERNAL FontStyle(fontStyle)
EXTERNAL FadeIn(speed)
EXTERNAL FadeOut(speed)

{Background("Cuarto")}
{Font("Monica")}
{Name("")}

\*Rrrrrrrrring*
\*Rrrrrrrrring*

{Name("Monica")}
{Icon("Monica/Monica_Ome")}

\*Bostezo*

Buenos dias Ome
Despierta pequeño roñoso

{Name("Ome")}
\*Grrrr*

{FontStyle("Normal")}
{Name("Monica")}
Vamos Ome.
Hoy toca desayunar huevito con salchichas, si te portas bien te daré algunas de mi plato.

{Name("")}
\*Ome sale corriendo*

{Name("Monica")}
{Icon("Monica_IRL")}
¡Oh, bueno, a ese no hay que decirle las cosas dos veces!
Tengo que preparame para bajar a desayunar

VAR limpia = false
VAR dientes = false
VAR bano = false
VAR cambio = false

-> opciones_limpieza

== opciones_limpieza

    * [Lavarse los dientes]
    ~ dientes = true
    El sabor a menta me devuelve la vida -> opciones_limpieza
    * [Ir al baño]
    ~ bano = true
    Uff, me siento mejor. -> opciones_limpieza
    * [Vestirse]
    ~ cambio = true
    Bien, ahora podemos ir a desayunar. -> opciones_limpieza
    * [Salir del cuarto]
    {dientes and bano and cambio: 
        ~ limpia = true
    }
    {FadeOut(2)} -> afuera_cuarto
    
== afuera_cuarto
    {Icon("")}
    {Background("Pasillo")}
    {Name("")}
    {FadeIn(2)}
    ...
    {Name("Santiago")}
    {Icon("Monstruo1/Frame1")}
    Buenos dias mi Monita.
    ¿Cómo amaneciste hoy?
    {not limpia: 
        Ya veo que algo apestosilla
        ¿Por qué no vas a alistarte antes de ir a desayunar mi niña?
    }
    -> END
    
    




