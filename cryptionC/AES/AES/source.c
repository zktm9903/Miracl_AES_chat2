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

        char* ptr = strtok(numBlock, " ");      // " " ���� ���ڸ� �������� ���ڿ��� �ڸ�, ������ ��ȯ

        while (ptr != NULL)               // �ڸ� ���ڿ��� ������ ���� ������ �ݺ�
        {
            //printf("%s\n", ptr);          // �ڸ� ���ڿ� ���
            block[t++] = atoi(ptr);
            ptr = strtok(NULL, " ");      // ���� ���ڿ��� �߶� �����͸� ��ȯ
        }

        aes_decrypt(&a, block);
        printf("%s", block);
    }


    aes_end(&a);
    printf("@");
    return 0;
}
