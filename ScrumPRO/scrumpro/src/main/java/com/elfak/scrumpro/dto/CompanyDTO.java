package com.elfak.scrumpro.dto;

import com.elfak.scrumpro.enumeration.RoleEnum;
import lombok.*;

@Builder
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class CompanyDTO {

    private Long id;
    private String name;
    private RoleEnum role;
}
