rem ファイルリストを自分で書いて読み込んでループ。
for /f %%x in (importfiles.txt) do (
    rem 文字コードをUTFにした一時ファイルを作成
    iconv -f Shift-JIS  -t UTF-8 %%x > %%x.utf 

    rem UTFの一時ファイルをインポート
    mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master %%x.utf

    rem 一時ファイル削除
    del %%x.utf
)


