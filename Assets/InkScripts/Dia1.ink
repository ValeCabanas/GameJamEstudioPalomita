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
{Icon("Monica/Monica_Pijama_Ome")}

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
{Icon("Monica/Monica_Pijama")}
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
    {Icon("Monica_IRL")}
    Bien, ahora podemos ir a desayunar. -> opciones_limpieza
    * [Salir del cuarto]
    {dientes and bano and cambio: 
        ~ limpia = true
    }
    {not limpia:
        Me voy a cambiar antes de bajar
    }
    {FadeOut(2)} -> afuera_cuarto
    
== afuera_cuarto
    {Icon("")}
    {Name("")}
    {Background("Pasillo")}
    {FadeIn(2)}
    ...
    {Name("Santiago")}
    {Icon("Awelo")}
    Buenos dias mi Monita.
    ¿Cómo amaneciste hoy?
    {not limpia: 
        Ya veo que algo apestosilla
        ¿Por qué no vas a alistarte antes de ir a desayunar mi niña?
    }
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    \*Beso en la mejilla*
    Bien Santito, dormí perfectamente y Ome como siempre no quería despertar, es un gato muy flojo.
    
    {Name("Santiago")}
    {Icon("Awelo")}
     Si… vi como salío más rápido que el diablo de tu habitación, pero con estos huesos tan viejos, no me fue posible atrapar a la pequeña alimaña
     
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Perdón Santito… te prometo que ya no le voy a dejar salir en las noches.
    Hace cada diablura que hasta a ti que tienes tanta paciencia te desquicia.
    
    {Name("Santiago")}
    {Icon("Awelo")}
    Bueno… lo perdono.
    Pero sólo porque tu me lo pides, porque eres mi mejor nietecita.
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Soy tu única nieta Santito.
    
    {Icon("")}
    {Name("")}
    ...
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Santito… ¿no quieres que te ayude a bajar las escaleras?
     
    {Name("Santiago")}
    {Icon("Awelo")}
    Ahhh… tú siempre un encanto.
    Que hermosa chamaca.
    Ven, vamos, bajemos juntos.
    
    {FadeOut(2)} -> cocina
    
== cocina
    {Icon("")}
    {Name("")}
    {Background("Cocina")}
    {FadeIn(2)}
    ...
    
    {Icon("Laura")}
    {Name("Laura")}
    Buenos días familia.
    
    {Icon("")}
    {Name("Todos")}
    ¡Hola, buenos días!
    
    {Icon("Laura")}
    {Name("Laura")}
    Suegro… anoche su hijo no llegó a la casa.
    ¿Le comentó algo de que estuviera trabajando?
    
    {Name("Santiago")}
    {Icon("Awelo")}
    Ay Laurita cariño, si tu que eres su esposa ni te avisa en donde anda tu crees que a su anciano padre siquiera le dirige un hola…
    
    {Icon("Laura")}
    {Name("Laura")}
    Bueno suegro…
    Pues ya a ver si más tarde llega, tal vez sería bueno que hablaran de vez en cuando.
     
    {Name("Santiago")}
    {Icon("Awelo")}
    Lo mismo te digo a ti hija…
    Tu me pelas más que ese desgraciado y eso que yo le he cuidado toda su vida.
    
    {Icon("Laura")}
    {Name("Laura")}
    Suegro… tampoco es tan mal hijo…
    Se esfuerza bastante por nosotros…

    {Icon("")}
    {Name("")}
    ...
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Ome, gato goloso, dije pocas y ya fueron muchas.
    
    {Icon("Laura")}
    {Name("Laura")}
    Ay niña… ni que tu se las compraras.
    Yo le voy a dar más salchichas y tu a la escuela, seguro Alex ya se cansó de esperarte.
    
    {Name("Monica")}
    {Icon("Monica/Monica_Asustada")}
    ¡Si es cierto! Pobre Alex
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Ya me voy familia.
    
    {Icon("")}
    {Name("Todos")}
    Adios, buen día.
    
    {FadeOut(2)} -> calle
    
== calle
    {Icon("")}
    {Name("")}
    {Background("Calle")}
    {FadeIn(2)}
    ...
    
    {Name("Monica")}
    {Icon("Monica_IRL")}
    Hola Alex ¿Cómo te va en tu mañana?
    
    {Name("Alex")}
    {Icon("Alex_IRL")}
    No me quejo, no hay ni frío ni calor
    Está fina esta mañana
    
    -> END
    
    




