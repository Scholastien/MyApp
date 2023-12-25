load('ext://helm_resource', 'helm_resource', 'helm_repo')


# TODO: port forward if necessary
helm_resource(
    'postgres', 
    'oci://registry-1.docker.io/bitnamicharts/postgresql', 
    flags=['--values', './postgres.yaml']
    #port_forwards=[port_forward(5433, 5433, name='WebAppDb')]
    )

# TODO: Live update to reduce compilation time on change
docker_build(
    'webapi',
    context='.',
    dockerfile="Dockerfile",
#    target='debug',
#    live_update=[
#        sync('./src', '/src/src/'),
#        run('dotnet build src/WebApi/WebApi.csproj && dotnet publish src/WebApi/WebApi.csproj')
#    ]
    )

k8s_yaml("./k8s-deployment.yaml")

k8s_resource(
    'webapi',
    port_forwards=[port_forward(3000,80, name='WebApi')]
    )