#include <stdio.h>
#include "miracl.h"
#include <time.h>

char* primetext =
"155315526351482395991155996351231807220169644828378937433223838972232518351958838087073321845624756550146945246003790108045940383194773439496051917019892370102341378990113959561895891019716873290512815434724157588460613638202017020672756091067223336194394910765309830876066246480156617492164140095427773547319";

int main(int argc, char* argv[])
{
    time_t seed;
    big a, b, p, pa, pb, key;
    miracl* mip;
    char* myA;
    char* yourPB;

#ifndef MR_NOFULLWIDTH   
    mip = mirsys(36, 0);
#else
    mip = mirsys(36, MAXBASE);
#endif

    a = mirvar(0);
    b = mirvar(0);
    p = mirvar(0);
    pa = mirvar(0);
    pb = mirvar(0);
    key = mirvar(0);

    time(&seed);
    irand((unsigned long)seed);

    cinstr(p, primetext);

    if (argv[1][0] == '1') {
        
        bigbits(160, a);

        powltr(3, a, p, pa);
        printf("@");
        cotnum(a, stdout);
        printf("@");
        cotnum(pa, stdout);
        printf("@");

    }
    
    else if (argv[1][0] == '2') {

        myA = argv[2];
        yourPB = argv[3];

        cinstr(a, myA);
        cinstr(pb, yourPB);

        powmod(pb, a, p, key);

        printf("@");
        cotnum(key, stdout);
        printf("@");

    }
    
    return 0;
}

