rem �������B�B�B�蔲���ł��B�B�B�B
rem �f�B���N�g���̒��g�𒊏o���ă��[�v�������������񂾂��Ǘ͐s����orz
iconv -f Shift-JIS  -t UTF-8 test.csv > test.utf
mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master test.utf

