package com.elfak.scrumpro.dto;

import lombok.*;

@Builder
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class ProjectUserDTO {

    private Long projectId;
    private Long userId;
}
