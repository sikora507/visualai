<template>
    <div>
        <h2>Simple neural network</h2>
        <p>2 input signals 3 hidden neurons and single output. 3 layers with step by step walkthrough.</p>
        <div id="visualization"></div>
    </div>
</template>
<script>
    import { DataSet, Network } from 'vis';
    export default {
        mounted: function () {
            var container = document.getElementById('visualization');
            fetch(`api/SimpleNetwork/GetSimpleNetwork`)
                .then(response => response.json())
                .then(data => {
                    var network = new Network(container, data, {
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
        }
    }
</script>
<style scoped>
    #visualization {
        height: 500px;
    }
</style>