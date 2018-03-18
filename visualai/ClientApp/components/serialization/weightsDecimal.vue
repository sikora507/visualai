<template>
    <div>
        <h4>Weights decimal</h4>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>#</th>
                    <th v-for="(w, index) in neurons">{{index+1}}</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(id, row) in neurons">
                    <td>{{row+1}}</td>
                    <td v-for="(n, column) in neurons">
                        {{decimalWeights[row*neurons.length+column]}}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>
    export default {
        props: ['weights'],
        computed: {
            neurons: function () {
                if (!this.weights) {
                    return [];
                }
                var result = [];
                for (var i = 0; i < Math.sqrt(this.weights.length); i++) {
                    result.push(i + 1);
                }
                return result;
            },
            decimalWeights: function () {
                if (!this.weights) {
                    return [];
                } 
                var result = this.weights.map(value => {
                    return value = parseFloat(Math.round(value * 100) / 100).toFixed(2);
                });
                return result;
            }
        }
    }
</script>
<style>
</style>