#include <stdlib.h> 
#include <string.h>
#include "miracl.h"


char* key;

int main(int argc, char* argv[])
{
    int nk = 16;
    aes a;
    char block[100];

    key = argv[2];

    int cnt = 0;
    int t = 0;

    printf("@");
    if (!aes_init(&a, MR_ECB, nk, key, NULL))
    {
        printf("Failed to Initialize\n");
        return 0;
    }

    if (argv[1][0] == 'E') {
        for (int i = 3; i < argc; i++) {
            for (int j = 0; j < strlen(argv[i]); j++) {
                block[cnt++] = argv[i][j];
            }
            block[cnt++] = 32;
        }
        for (int i = cnt; i < 17; i++) {
            block[i] = 0;
        }

        aes_encrypt(&a, block);
        for (int i = 0; i < 16; i++) printf("%d ", (unsigned char)block[i]);
    }
    else {
        char numBlock[100];
        for (int i = 3; i < argc; i++) {
            for (int j = 0; j < strlen(argv[i]); j++) {
                numBlock[cnt++] = argv[i][j];
            }
            numBlock[cnt++] = 32;
        }
        for (int i = cnt; i < 17; i++) {
            block[i] = 0;
        }

        char* ptr = strtok(numBlock, " ");      // " " 공백 문자를 기준으로 문자열을 자름, 포인터 반환

        while (ptr != NULL)               // 자른 문자열이 나오지 않을 때까지 반복
        {
            //printf("%s\n", ptr);          // 자른 문자열 출력
            block[t++] = atoi(ptr);
            ptr = strtok(NULL, " ");      // 다음 문자열을 잘라서 포인터를 반환
        }

        aes_decrypt(&a, block);
        printf("%s", block);
    }


    aes_end(&a);
    printf("@");
    return 0;
}
