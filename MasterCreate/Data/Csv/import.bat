rem �t�@�C�����X�g�������ŏ����ēǂݍ���Ń��[�v�B
for /f %%x in (importfiles.txt) do (
    rem �����R�[�h��UTF�ɂ����ꎞ�t�@�C�����쐬
    iconv -f Shift-JIS  -t UTF-8 %%x > %%x.utf 

    rem UTF�̈ꎞ�t�@�C�����C���|�[�g
    mysqlimport -u root --password=password --local --delete --fields-enclosed-by \" --ignore-lines=1  --fields-terminated-by , --lines-terminated-by \n --host 192.168.10.101 --default-character-set=utf8 test_master %%x.utf

    rem �ꎞ�t�@�C���폜
    del %%x.utf
)


