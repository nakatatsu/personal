rem �������B�B�B�蔲���ł��B�B�B�B
rem �f�B���N�g���̒��g�𒊏o���ă��[�v�������������񂾂��Ǘ͐s����orz �B�B�B���ď��Ԃ������ŋK�肵�Ȃ��Ƃ����Ȃ��񂾂����B�f�B���N�g���ǂގ��͌����炾�߂����B
rem �Ƃ����킯�Ńt�@�C�����X�g�������ŏ����ēǂݍ��ގ��ɂ����B
for /f %%x in (importfiles.txt) do (
    iconv -f Shift-JIS  -t UTF-8 %%x > %%x.utf 
    mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master %%x.utf
    del %%x.utf
)


