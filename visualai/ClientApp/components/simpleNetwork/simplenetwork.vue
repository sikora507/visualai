<template>
    <div id="visualization"></div>
</template>
<script>
    import { DataSet, Network } from 'vis';
    var nodes = null;
    export default {
        props: ['newData'],
        mounted: function () {
            var container = document.getElementById('visualization');
            fetch(`api/SimpleNetwork/GetSimpleNetwork`)
                .then(response => response.json())
                .then(data => {
                    nodes = new DataSet();
                    data.nodes.forEach((item) => { nodes.add(item); });
                    var network = new Network(container, { nodes: nodes, edges: data.edges }, {
                        nodes: {
                            shape: 'box',
                            color: {
                                background: 'cornsilk',
                                border: 'gray',
                                highlight: {
                                    background: 'cornsilk', border: 'gray'
                                }
                            }
                        },
                        edges: {
                            arrows: {
                                to: {
                                    enabled: true
                                }
                            }
                        },
                        layout: {
                            hierarchical: {
                                direction: 'LR',
                                sortMethod: 'directed'
                            }
                        },
                        interaction: {
                            //dragNodes: false,
                            //dragView: false,
                            hoverConnectedEdges: false,
                            //selectable: false,
                            selectConnectedEdges: false,
                        }
                    });
                });
        },
        watch: {
            newData: function (data) {
                if (data) {
                    data.nodes.forEach((item) => {
                        nodes.update(item);
                    });
                }
            }
        }
    }
</script>
<style scoped>
    #visualization {
        height: 500px;
    }
</style>