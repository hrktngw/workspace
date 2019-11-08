#include <stdio.h>

int main () {

  // 文字列を指定する場合はchar配列を使用
  // 初期化方法は様々
  char str1[6] = {'H','I','R','O','K','I'};
  char str2[] = "HIROKI";
  char str3[7];
  str3[0] = 'H';
  str3[1] = 'I';
  str3[2] = 'R';
  str3[3] = 'O';
  str3[4] = 'K';
  str3[5] = 'I';
  str3[6] = '\0';

  printf ("str1 = %s\n", str1);
  printf ("str2 = %s\n", str2);
  printf ("str3 = %s\n", str3);
  return 0;
}
