$currentDir = Resolve-Path "./"
Start-Process 'powershell.exe' -Verb runAs -WorkingDirectory $currentDir
ls
