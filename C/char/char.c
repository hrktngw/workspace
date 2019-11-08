#include <stdio.h>
/* 最大数の定義を読み込み */
#include <limits.h>

int main ()
{
  // charは文字列として扱われているが、内部的には整数値である
  char temp = CHAR_MIN;
  printf("char型のデーターサイズ: %d bit\n", CHAR_BIT);
  printf("==== char 一覧 ====\n");

  // charで取り扱える文字列を全て列挙
  while (1) {
    // output
    printf ("%4d = %c\t\n", temp,temp);
    temp++;

    // break
    if (temp == CHAR_MAX) {
      break;
    }
  }
  return 0;
}
