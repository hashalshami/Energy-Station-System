@echo off
set /p commit_message=Enter Commit Message (Commit Message): 
git add *
git commit -m "%commit_message%"
git branch -M master
git push origin master
pause
