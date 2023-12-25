load('ext://helm_resource', 'helm_resource', 'helm_repo')

helm_resource(
    'postgres', 
    'oci://registry-1.docker.io/bitnamicharts/postgresql', 
    flags=['--values', './postgres.yaml'],
    port_forwards=[port_forward(5432, 5433, name='WebAppDb')]
    )

docker_build(
    'webapi',
    context='.',
    dockerfile="Dockerfile"
    )

k8s_yaml("./k8s-deployment.yaml")

k8s_resource(
    'webapi',
    port_forwards=[port_forward(3000,80, name='WebApi')]
    )