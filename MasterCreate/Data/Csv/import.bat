rem すごく。。。手抜きです。。。。
rem ディレクトリの中身を抽出してループさせたかったんだけど力尽きたorz
iconv -f Shift-JIS  -t UTF-8 test.csv > test.utf
mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master test.utf

