<template>
    <div>
        <h4>Connections presence</h4>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>#</th>
                    <th v-for="id in neuronIds">{{id}}</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(id, row) in neuronIds">
                    <td>{{id}}</td>
                    <td v-for="(n, column) in neuronIds" v-bind:class="{ silver: !connections[row*neuronsCount+column] }">
                        <span v-bind:class="{ 'badge badge-info': connections[row*neuronsCount+column] }">
                            {{connections[row*neuronsCount+column]}}
                        </span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>
    export default {
        props: ['connections'],
        data: function () {
            return {
                neuronsCount: 0,
                neuronIds: []
            }
        },
        watch: {
            connections: function (val) {
                if (val) {
                    this.neuronsCount = Math.sqrt(val.length);
                    for (var i = 0; i < this.neuronsCount; i++) {
                        this.neuronIds.push(i+1);
                    }
                }
            }
        }
    }
</script>
<style scoped>
    .silver {
        color: silver;
    }
    .badge-info {
        background-color: #3a87ad;
    }
</style>