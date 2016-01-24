rem すごく。。。手抜きです。。。。
rem ディレクトリの中身を抽出してループさせたかったんだけど力尽きたorz 。。。って順番を自分で規定しないといけないんだった。ディレクトリ読む式は元からだめじゃん。
rem というわけでファイルリストを自分で書いて読み込む式にした。
for /f %%x in (importfiles.txt) do (
    iconv -f Shift-JIS  -t UTF-8 %%x > %%x.utf 
    mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master %%x.utf
    del %%x.utf
)


