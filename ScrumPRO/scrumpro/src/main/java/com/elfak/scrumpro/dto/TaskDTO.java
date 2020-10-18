package com.elfak.scrumpro.dto;

import com.elfak.scrumpro.enumeration.TaskEnum;
import kong.unirest.json.JSONObject;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

import java.io.Serializable;

@Builder
@Getter
@Setter
public class TaskDTO implements Serializable {
    private Long id;
    private String name;
    private String content;
    private TaskEnum state;
    private Long projectId;

    @Override
    public String toString() {
        JSONObject jsonInfo = new JSONObject();

        jsonInfo.put("id", this.id);
        jsonInfo.put("name", this.name);
        jsonInfo.put("content", this.content);
        jsonInfo.put("state", this.state);
        jsonInfo.put("projectId", this.projectId);

        return jsonInfo.toString();
    }
}
