import re
import os
import mtranslate
def unicode_to_char(unicode_str):
    return chr(int(unicode_str[2:], 16)) if unicode_str.startswith("\\u") else unicode_str

def process_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        content = file.read()
    def replace_unicode_in_quotes(match):
        quoted_str = re.sub('\n','',match.group())
        print(quoted_str)
        translated_sentence = mtranslate.translate(re.sub(r'(\\u[0-9a-fA-F]{4})', lambda x: unicode_to_char(x.group()), quoted_str),'en','auto')
        print(translated_sentence)
        return translated_sentence
    content_with_replaced_unicode = re.sub(r'"(.*?)"', replace_unicode_in_quotes, content, flags=re.DOTALL)
    return content_with_replaced_unicode

if __name__ == "__main__":
    file_path = input("Enter the path to the text file: ")
    translated_content = process_file(file_path)
    f = open(os.path.join(os.path.dirname(file_path), f"{os.path.basename(file_path)}[TRANSLATED]"), "x")
    f.write(translated_content)
    print("Done, Now go fix my mistakes")