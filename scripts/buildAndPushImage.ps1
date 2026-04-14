Set-Location ..
Set-Location TestTask

docker build -t kakaby13/test-task-13.04.2026:latest .
docker push kakaby13/test-task-13.04.2026:latest
