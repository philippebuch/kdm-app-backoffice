import axios from 'axios'

export default class EntityService
{
    constructor()
    {
    }

    async getEntityTemplates()
    {
        let response = await axios.get("api/Entity/Template");
        return response.data;
    }

    async getPrompts()
    {
        let response = await axios.get("api/Entity/Prompt");
        return response.data;
    }

    async getEntities()
    {
        let response = await axios.get("api/Entity/Entity");
        return response.data;
    }

    async createEntity(template)
    {
        let response = await axios.post("api/Entity/Entity", template);
        return response.data;
    }
}