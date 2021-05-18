artillery run -e local load-tests-sitecontagem.yml

artillery run -o results.json -e local load-tests-sitecontagem.yml

artillery report -o results.html results.json