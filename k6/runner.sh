# !/bin/bash

docker run --rm -i --network host grafana/k6 run - <script.js