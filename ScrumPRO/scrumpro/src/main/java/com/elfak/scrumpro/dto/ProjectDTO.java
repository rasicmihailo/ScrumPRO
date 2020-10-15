package com.elfak.scrumpro.dto;

import lombok.*;

@Builder
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class ProjectDTO {

    private String name;
    private Long companyId;
}
