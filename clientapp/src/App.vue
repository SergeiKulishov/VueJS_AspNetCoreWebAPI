<template>
    <div class="container">
        <Persons/>
    </div>
</template>

<script>
    import Persons from "./components/Persons/Persons";

    export default {
        name: 'App',
        components: {
            Persons
        }
    }
</script>

<style src="./App.css"></style>
