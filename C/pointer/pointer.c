#include <stdio.h>

int main () {
  int i1,i2,i3;

  // ポインタの出力フォーマットは%p
  printf ("pointer: i1 = %p\n", &i1);
  printf ("pointer: i2 = %p\n", &i2);
  printf ("pointer: i3 = %p\n", &i3);

  printf ("配列のポインタ例\n");
  printf ("配列のポインタと、配列の0番目の要素のポインタは同じ参照を持つ\n");
  int array[10];
  printf("pointer: array = %p\n", array);
  for (int i = 0; i < 10; i++) {
    printf ("pointer: array[%d] = %p\n", i, &array[i]);
  }
  return 0;
}
