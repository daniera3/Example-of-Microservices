import subprocess
import sys
print(len(sys.argv))
if(sys.argv[1]=='topJava'):
    if(len(sys.argv)>2):
        subprocess.call(['java', '-jar', 'TOP.jar'],sys.argv[2])
    else:
        subprocess.call(['java', '-jar', 'TOP.jar'])
                        
elif(sys.argv[1]=='retriverJava'):
    if(len(sys.argv)>2):
        subprocess.call(['java', '-jar', 'retriver.jar'],sys.argv[2])
    else:
        subprocess.call(['java', '-jar', 'retriver.jar'])
    
