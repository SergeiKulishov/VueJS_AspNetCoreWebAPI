<template>
    <div>
        <Multiselect
                v-model="value"
                placeholder="Select your organizations"
                mode="tags"
                @select="multiselect"
                :options="options"
        />
    </div>
</template>

<script>
    import Multiselect from '@vueform/multiselect'

    export default {
        components: {
            Multiselect,
        },
        data() {
            return {
                value: null,
                options: [
                    'Oracle',
                    'Google',
                    'Tesla',
                    'Yahoo'
                ],
            }
        },
        methods: {
            multiselect() {
                console.log("multiselect()")
                this.$emit('multiselect', {
                    data: this.value
                })
            }
        }
    }
</script>

<style src="../../node_modules/@vueform/multiselect/themes/default.css"></style>
